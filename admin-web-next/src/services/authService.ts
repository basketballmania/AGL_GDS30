import axios from 'axios';

const API_BASE_URL = process.env.NEXT_PUBLIC_API_URL || 'https://localhost:7228/v1';

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  refreshToken: string;
  expiresAt: string;
  admin: {
    id: number;
    email: string;
    name: string;
    role: string;
  };
}

export interface CreateAdminRequest {
  email: string;
  password: string;
  name: string;
  role?: string;
}

export interface UpdateAdminRequest {
  name?: string;
  role?: string;
  isActive?: boolean;
}

export interface ChangePasswordRequest {
  currentPassword: string;
  newPassword: string;
}

class AuthService {
  private token: string | null = null;

  constructor() {
    if (typeof window !== 'undefined') {
      this.token = localStorage.getItem('admin_token');
    }
  }

  setToken(token: string) {
    this.token = token;
    if (typeof window !== 'undefined') {
      localStorage.setItem('admin_token', token);
    }
  }

  getToken(): string | null {
    return this.token;
  }

  removeToken() {
    this.token = null;
    if (typeof window !== 'undefined') {
      localStorage.removeItem('admin_token');
    }
  }

  private getAuthHeaders() {
    return {
      'Authorization': `Bearer ${this.token}`,
      'Content-Type': 'application/json',
    };
  }

  // 로그인
  async login(credentials: LoginRequest): Promise<LoginResponse> {
    try {
      const response = await axios.post(`${API_BASE_URL}/admin/login`, credentials);
      const data = response.data;
      this.setToken(data.token);
      return data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '로그인에 실패했습니다.');
    }
  }

  // 로그아웃
  logout() {
    this.removeToken();
  }

  // 관리자 생성
  async createAdmin(adminData: CreateAdminRequest): Promise<any> {
    try {
      const response = await axios.post(`${API_BASE_URL}/admin`, adminData, {
        headers: this.getAuthHeaders(),
      });
      return response.data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '관리자 생성에 실패했습니다.');
    }
  }

  // 관리자 목록 조회
  async getAdmins(): Promise<any[]> {
    try {
      const response = await axios.get(`${API_BASE_URL}/admin`, {
        headers: this.getAuthHeaders(),
      });
      return response.data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '관리자 목록 조회에 실패했습니다.');
    }
  }

  // 관리자 상세 조회
  async getAdminById(id: number): Promise<any> {
    try {
      const response = await axios.get(`${API_BASE_URL}/admin/${id}`, {
        headers: this.getAuthHeaders(),
      });
      return response.data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '관리자 조회에 실패했습니다.');
    }
  }

  // 관리자 수정
  async updateAdmin(id: number, adminData: UpdateAdminRequest): Promise<any> {
    try {
      const response = await axios.put(`${API_BASE_URL}/admin/${id}`, adminData, {
        headers: this.getAuthHeaders(),
      });
      return response.data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '관리자 수정에 실패했습니다.');
    }
  }

  // 관리자 비활성화
  async deactivateAdmin(id: number): Promise<any> {
    try {
      const response = await axios.delete(`${API_BASE_URL}/admin/${id}`, {
        headers: this.getAuthHeaders(),
      });
      return response.data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '관리자 비활성화에 실패했습니다.');
    }
  }

  // 비밀번호 변경
  async changePassword(id: number, passwordData: ChangePasswordRequest): Promise<any> {
    try {
      const response = await axios.put(`${API_BASE_URL}/admin/${id}/change-password`, passwordData, {
        headers: this.getAuthHeaders(),
      });
      return response.data;
    } catch (error: any) {
      throw new Error(error.response?.data?.message || '비밀번호 변경에 실패했습니다.');
    }
  }

  // 토큰 유효성 검사
  async validateToken(): Promise<boolean> {
    if (!this.token) return false;
    
    try {
      await axios.get(`${API_BASE_URL}/admin`, {
        headers: this.getAuthHeaders(),
      });
      return true;
    } catch (error) {
      this.removeToken();
      return false;
    }
  }
}

export const authService = new AuthService(); 