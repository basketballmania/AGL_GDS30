'use client';

import { useState, useEffect } from 'react';
import { authService } from '@/services/authService';

interface Admin {
  id: number;
  email: string;
  name: string;
  role: string;
  isActive: boolean;
  createdAt: string;
}

export default function AdminsPage() {
  const [admins, setAdmins] = useState<Admin[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    loadAdmins();
  }, []);

  const loadAdmins = async () => {
    try {
      setLoading(true);
      const data = await authService.getAdmins();
      setAdmins(data);
    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  const handleDeactivate = async (id: number) => {
    if (!confirm('정말로 이 관리자를 비활성화하시겠습니까?')) {
      return;
    }

    try {
      await authService.deactivateAdmin(id);
      await loadAdmins(); // 목록 새로고침
    } catch (err: any) {
      setError(err.message);
    }
  };

  if (loading) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <div className="text-lg">로딩 중...</div>
      </div>
    );
  }

  return (
    <div className="p-6">
      <div className="mb-6">
        <h1 className="text-2xl font-bold text-gray-900">관리자 목록</h1>
        <p className="text-gray-600">시스템 관리자 계정들을 관리합니다.</p>
      </div>

      {error && (
        <div className="mb-4 p-4 bg-red-50 border border-red-200 rounded-md">
          <p className="text-red-600">{error}</p>
        </div>
      )}

      <div className="bg-white shadow overflow-hidden sm:rounded-md">
        <ul className="divide-y divide-gray-200">
          {admins.map((admin) => (
            <li key={admin.id} className="px-6 py-4">
              <div className="flex items-center justify-between">
                <div className="flex items-center">
                  <div className="flex-shrink-0">
                    <div className="h-10 w-10 rounded-full bg-indigo-100 flex items-center justify-center">
                      <span className="text-indigo-600 font-medium">
                        {admin.name.charAt(0)}
                      </span>
                    </div>
                  </div>
                  <div className="ml-4">
                    <div className="text-sm font-medium text-gray-900">
                      {admin.name}
                    </div>
                    <div className="text-sm text-gray-500">
                      {admin.email}
                    </div>
                    <div className="text-xs text-gray-400">
                      역할: {admin.role} | 생성일: {new Date(admin.createdAt).toLocaleDateString()}
                    </div>
                  </div>
                </div>
                <div className="flex items-center space-x-2">
                  <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                    admin.isActive 
                      ? 'bg-green-100 text-green-800' 
                      : 'bg-red-100 text-red-800'
                  }`}>
                    {admin.isActive ? '활성' : '비활성'}
                  </span>
                  {admin.isActive && (
                    <button
                      onClick={() => handleDeactivate(admin.id)}
                      className="text-red-600 hover:text-red-800 text-sm font-medium"
                    >
                      비활성화
                    </button>
                  )}
                </div>
              </div>
            </li>
          ))}
        </ul>
      </div>

      {admins.length === 0 && !loading && (
        <div className="text-center py-12">
          <p className="text-gray-500">등록된 관리자가 없습니다.</p>
        </div>
      )}
    </div>
  );
} 