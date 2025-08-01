'use client'

import Link from 'next/link'
import { useState, useEffect } from 'react'

// 상품 타입 정의
interface Product {
  id: number
  name: string
  description: string
  basePrice: number
  stockQuantity: number
  isActive: boolean
  skuOptions: string
  createdAt: string
  updatedAt: string
  productSkus?: ProductSku[]
}

interface ProductSku {
  id: number
  productId: number
  skuCode: string
  optionCombination: string
  price: number
  stockQuantity: number
  isActive: boolean
}

// API 함수들
const API_BASE_URL = 'https://localhost:7228/v1'

const fetchProducts = async (adminId: number, page: number = 1, pageSize: number = 20) => {
  try {
    console.log('API 호출 시작:', `${API_BASE_URL}/product/admin/${adminId}?page=${page}&pageSize=${pageSize}`)
    const response = await fetch(`${API_BASE_URL}/product/admin/${adminId}?page=${page}&pageSize=${pageSize}`)
    console.log('API 응답 상태:', response.status, response.statusText)
    if (!response.ok) {
      throw new Error('상품 목록을 불러오는데 실패했습니다.')
    }
    const data = await response.json()
    console.log('API 응답 데이터:', data)
    return data
  } catch (error) {
    console.error('상품 목록 조회 오류:', error)
    throw error
  }
}

const searchProducts = async (searchTerm: string, page: number = 1, pageSize: number = 20) => {
  try {
    const response = await fetch(`${API_BASE_URL}/product/search?searchTerm=${encodeURIComponent(searchTerm)}&page=${page}&pageSize=${pageSize}`)
    if (!response.ok) {
      throw new Error('상품 검색에 실패했습니다.')
    }
    return await response.json()
  } catch (error) {
    console.error('상품 검색 오류:', error)
    throw error
  }
}

const createProduct = async (adminId: number, productData: any) => {
  try {
    const response = await fetch(`${API_BASE_URL}/product/create/${adminId}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(productData),
    })
    if (!response.ok) {
      throw new Error('상품 생성에 실패했습니다.')
    }
    return await response.json()
  } catch (error) {
    console.error('상품 생성 오류:', error)
    throw error
  }
}

const updateProduct = async (adminId: number, productId: number, productData: any) => {
  try {
    const response = await fetch(`${API_BASE_URL}/product/update/${adminId}/${productId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(productData),
    })
    if (!response.ok) {
      throw new Error('상품 수정에 실패했습니다.')
    }
    return await response.json()
  } catch (error) {
    console.error('상품 수정 오류:', error)
    throw error
  }
}

const deactivateProduct = async (adminId: number, productId: number) => {
  try {
    const response = await fetch(`${API_BASE_URL}/product/deactivate/${adminId}/${productId}`, {
      method: 'POST',
    })
    if (!response.ok) {
      throw new Error('상품 비활성화에 실패했습니다.')
    }
    return await response.json()
  } catch (error) {
    console.error('상품 비활성화 오류:', error)
    throw error
  }
}

export default function ProductsPage() {
  const [products, setProducts] = useState<Product[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)
  const [searchTerm, setSearchTerm] = useState('')
  const [currentPage, setCurrentPage] = useState(1)
  const [totalPages, setTotalPages] = useState(1)
  const [showCreateModal, setShowCreateModal] = useState(false)
  const [showEditModal, setShowEditModal] = useState(false)
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null)
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    basePrice: 0,
    stockQuantity: 0,
    skuOptions: '',
    isActive: true
  })

  const [options, setOptions] = useState<Array<{name: string, values: Array<{value: string, price: number}>}>>([])
  const [newOptionName, setNewOptionName] = useState('')
  const [newOptionValues, setNewOptionValues] = useState('')

  // 임시 관리자 ID (실제로는 로그인된 관리자 정보를 사용)
  const adminId = 1

  // 상품 목록 조회
  const loadProducts = async () => {
    try {
      setLoading(true)
      setError(null)
      console.log('상품 목록 조회 시작...')
      const data = await fetchProducts(adminId, currentPage, 20)
      console.log('상품 목록 조회 성공:', data)
      setProducts(data)
      // 실제 API에서 페이지 정보를 받아와야 함
      setTotalPages(Math.ceil(data.length / 20) || 1)
    } catch (err) {
      console.error('상품 목록 조회 오류:', err)
      setError(err instanceof Error ? err.message : '상품 목록을 불러오는데 실패했습니다.')
    } finally {
      setLoading(false)
    }
  }

  // 상품 검색
  const handleSearch = async () => {
    if (!searchTerm.trim()) {
      await loadProducts()
      return
    }

    try {
      setLoading(true)
      setError(null)
      const data = await searchProducts(searchTerm, currentPage, 20)
      setProducts(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : '상품 검색에 실패했습니다.')
    } finally {
      setLoading(false)
    }
  }

  // 상품 생성
  const handleCreateProduct = async () => {
    try {
      const productData = {
        name: formData.name,
        description: formData.description,
        basePrice: parseFloat(formData.basePrice.toString()),
        stockQuantity: Number(formData.stockQuantity),
        skuOptions: convertOptionsToJson()
      }
      await createProduct(adminId, productData)
      setShowCreateModal(false)
      setFormData({
        name: '',
        description: '',
        basePrice: 0,
        stockQuantity: 0,
        skuOptions: '',
        isActive: true
      })
      setOptions([])
      await loadProducts()
    } catch (err) {
      setError(err instanceof Error ? err.message : '상품 생성에 실패했습니다.')
    }
  }

  // 상품 수정
  const handleUpdateProduct = async () => {
    if (!selectedProduct) return

    try {
      const productData = {
        name: formData.name,
        description: formData.description,
        basePrice: Number(formData.basePrice),
        stockQuantity: Number(formData.stockQuantity),
        skuOptions: convertOptionsToJson(),
        isActive: formData.isActive
      }
      await updateProduct(adminId, selectedProduct.id, productData)
      setShowEditModal(false)
      setSelectedProduct(null)
      setFormData({
        name: '',
        description: '',
        basePrice: 0,
        stockQuantity: 0,
        skuOptions: '',
        isActive: true
      })
      setOptions([])
      await loadProducts()
    } catch (err) {
      setError(err instanceof Error ? err.message : '상품 수정에 실패했습니다.')
    }
  }

  // 상품 비활성화
  const handleDeactivateProduct = async (productId: number) => {
    if (!confirm('정말로 이 상품을 비활성화하시겠습니까?')) return

    try {
      await deactivateProduct(adminId, productId)
      await loadProducts()
    } catch (err) {
      setError(err instanceof Error ? err.message : '상품 비활성화에 실패했습니다.')
    }
  }

  // 옵션 추가
  const addOption = () => {
    if (!newOptionName.trim() || !newOptionValues.trim()) return
    
    // 옵션명에 쉼표가 있으면 여러 옵션으로 분리
    const optionNames = newOptionName.split(',').map(name => name.trim()).filter(name => name)
    const optionValues = newOptionValues.split(',').map(v => v.trim()).filter(v => v)
    
    if (optionNames.length === 1) {
      // 단일 옵션인 경우
      const values = optionValues.map(value => ({ value, price: 0 }))
      setOptions([...options, { name: optionNames[0], values }])
    } else {
      // 여러 옵션인 경우 각각 분리
      const newOptions = [...options]
      optionNames.forEach((name, index) => {
        if (optionValues[index]) {
          newOptions.push({
            name,
            values: [{ value: optionValues[index], price: 0 }]
          })
        }
      })
      setOptions(newOptions)
    }
    
    setNewOptionName('')
    setNewOptionValues('')
  }

  // 옵션 제거
  const removeOption = (index: number) => {
    setOptions(options.filter((_, i) => i !== index))
  }

  // 옵션 값 제거
  const removeOptionValue = (optionIndex: number, valueIndex: number) => {
    const newOptions = [...options]
    newOptions[optionIndex].values = newOptions[optionIndex].values.filter((_, i) => i !== valueIndex)
    setOptions(newOptions)
  }

  // 옵션 값 추가
  const addOptionValue = (optionIndex: number, value: string) => {
    if (!value.trim()) return
    const newOptions = [...options]
    newOptions[optionIndex].values.push({ value: value.trim(), price: 0 })
    setOptions(newOptions)
  }

  // 옵션 가격 변경
  const updateOptionValuePrice = (optionIndex: number, valueIndex: number, price: number) => {
    const newOptions = [...options]
    newOptions[optionIndex].values[valueIndex].price = price
    setOptions(newOptions)
  }

  // 옵션을 JSON으로 변환
  const convertOptionsToJson = () => {
    // 새로운 형식으로 변환 (priceRules 포함)
    const priceRules: any[] = []
    
    // 모든 옵션 조합에 대해 가격 규칙 생성
    if (options.length >= 2) {
      const option1 = options[0]
      const option2 = options[1]
      
      option1.values.forEach((value1: any) => {
        option2.values.forEach((value2: any) => {
          if (value1.price > 0 || value2.price > 0) {
            priceRules.push({
              priceDiff: value1.price + value2.price,
              combination: {
                [option1.name]: value1.value,
                [option2.name]: value2.value
              }
            })
          }
        })
      })
    }
    
    return JSON.stringify({ 
      options: options.map(option => ({
        name: option.name,
        values: option.values.map(value => value.value) // 문자열 배열로 변환
      })),
      priceRules
    })
  }

  // JSON을 옵션으로 변환
  const convertJsonToOptions = (jsonString: string) => {
    try {
      const parsed = JSON.parse(jsonString)
      const options = parsed.options || []
      
      // 새로운 형식 지원 (priceRules가 있는 경우)
      if (parsed.priceRules) {
        // priceRules에서 가격 정보를 추출하여 옵션 값에 매핑
        const priceMap = new Map()
        parsed.priceRules.forEach((rule: any) => {
          const combination = rule.combination
          const key = `${combination.색상 || combination.사이즈}`
          priceMap.set(key, rule.priceDiff)
        })
        
        return options.map((option: any) => ({
          name: option.name,
          values: option.values.map((value: any) => {
            if (typeof value === 'string') {
              return { value, price: priceMap.get(value) || 0 }
            }
            return value
          })
        }))
      } else {
        // 기존 형식과 호환성을 위해 문자열 배열을 객체 배열로 변환
        return options.map((option: any) => ({
          name: option.name,
          values: option.values.map((value: any) => {
            if (typeof value === 'string') {
              return { value, price: 0 }
            }
            return value
          })
        }))
      }
    } catch {
      return []
    }
  }

  // 수정 모달 열기
  const openEditModal = (product: Product) => {
    setSelectedProduct(product)
    setFormData({
      name: product.name,
      description: product.description,
      basePrice: product.basePrice,
      stockQuantity: product.stockQuantity,
      skuOptions: product.skuOptions,
      isActive: product.isActive
    })
    // 기존 옵션을 파싱
    setOptions(convertJsonToOptions(product.skuOptions))
    setShowEditModal(true)
  }

  // 초기 로드
  useEffect(() => {
    console.log('컴포넌트 마운트 또는 currentPage 변경:', currentPage)
    loadProducts()
  }, [currentPage])

  // 검색어 변경 시 검색 실행
  useEffect(() => {
    const timer = setTimeout(() => {
      if (searchTerm) {
        handleSearch()
      } else {
        loadProducts()
      }
    }, 500)

    return () => clearTimeout(timer)
  }, [searchTerm])

  return (
    <div className="min-h-screen bg-gray-100">
      {/* Sidebar */}
      <div className="fixed inset-y-0 left-0 z-50 w-64 bg-gray-900">
        <div className="flex items-center justify-center h-16 bg-gray-800">
          <h1 className="text-xl font-bold text-white">AGL Admin</h1>
        </div>
        <nav className="mt-8">
          <div className="px-4 space-y-2">
            <Link
              href="/"
              className="flex items-center px-4 py-2 text-gray-300 hover:bg-gray-700 hover:text-white rounded-md"
            >
              <svg className="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M3 7v10a2 2 0 002 2h14a2 2 0 002-2V9a2 2 0 00-2-2H5a2 2 0 00-2-2z" />
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M8 5a2 2 0 012-2h4a2 2 0 012 2v6H8V5z" />
              </svg>
              대시보드
            </Link>
            <Link
              href="/products"
              className="flex items-center px-4 py-2 bg-gray-700 text-white rounded-md"
            >
              <svg className="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4m0-10L4 7m8 4v10M4 7v10l8 4" />
              </svg>
              상품 관리
            </Link>
            <Link
              href="/orders"
              className="flex items-center px-4 py-2 text-gray-300 hover:bg-gray-700 hover:text-white rounded-md"
            >
              <svg className="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 5H7a2 2 0 00-2 2v10a2 2 0 002 2h8a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2" />
              </svg>
              주문 관리
            </Link>
            <Link
              href="/users"
              className="flex items-center px-4 py-2 text-gray-300 hover:bg-gray-700 hover:text-white rounded-md"
            >
              <svg className="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z" />
              </svg>
              회원 관리
            </Link>
            <Link
              href="/analytics"
              className="flex items-center px-4 py-2 text-gray-300 hover:bg-gray-700 hover:text-white rounded-md"
            >
              <svg className="w-5 h-5 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
              </svg>
              통계
            </Link>
          </div>
        </nav>
      </div>

      {/* Main content */}
      <div className="pl-64">
        {/* Header */}
        <header className="bg-white shadow">
          <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <div className="flex justify-between items-center py-6">
              <h1 className="text-2xl font-semibold text-gray-900">상품 관리</h1>
                             <button 
                 onClick={() => {
                   setShowCreateModal(true)
                   // 상품 추가 모달 열 때 폼 데이터 초기화
                   setFormData({
                     name: '',
                     description: '',
                     basePrice: 0,
                     stockQuantity: 0,
                     skuOptions: '',
                     isActive: true
                   })
                   setOptions([])
                   setNewOptionName('')
                   setNewOptionValues('')
                 }}
                 className="bg-indigo-600 text-white px-4 py-2 rounded-md hover:bg-indigo-700"
               >
                 상품 추가
               </button>
            </div>
          </div>
        </header>

        {/* Main content */}
        <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
          {/* Error Message */}
          {error && (
            <div className="mb-4 bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded">
              {error}
            </div>
          )}

          {/* Filters */}
          <div className="mb-6">
            <div className="flex flex-col sm:flex-row gap-4">
              <div className="flex-1">
                <input
                  type="text"
                  placeholder="상품명으로 검색..."
                  value={searchTerm}
                  onChange={(e) => setSearchTerm(e.target.value)}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500"
                />
              </div>
            </div>
          </div>

          {/* Products Table */}
          <div className="bg-white shadow rounded-lg overflow-hidden">
            {loading ? (
              <div className="flex justify-center items-center py-8">
                <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-indigo-600"></div>
                <span className="ml-2 text-gray-600">상품 목록을 불러오는 중...</span>
              </div>
            ) : products.length === 0 ? (
              <div className="flex justify-center items-center py-8">
                <div className="text-center">
                  <svg className="mx-auto h-12 w-12 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4m0-10L4 7m8 4v10M4 7v10l8 4" />
                  </svg>
                  <h3 className="mt-2 text-sm font-medium text-gray-900">상품이 없습니다</h3>
                  <p className="mt-1 text-sm text-gray-500">새로운 상품을 추가해보세요.</p>
                </div>
              </div>
            ) : (
              <div className="overflow-x-auto">
                <table className="min-w-full divide-y divide-gray-200">
                  <thead className="bg-gray-50">
                    <tr>
                      <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        상품명
                      </th>
                      <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        설명
                      </th>
                      <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        기본가격
                      </th>
                      <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        재고
                      </th>
                      <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        상태
                      </th>
                      <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                        작업
                      </th>
                    </tr>
                  </thead>
                  <tbody className="bg-white divide-y divide-gray-200">
                    {products.map((product) => (
                      <tr key={product.id}>
                        <td className="px-6 py-4 whitespace-nowrap">
                          <div className="text-sm font-medium text-gray-900">{product.name}</div>
                        </td>
                        <td className="px-6 py-4">
                          <div className="text-sm text-gray-900 max-w-xs truncate">{product.description}</div>
                        </td>
                        <td className="px-6 py-4 whitespace-nowrap">
                          <div className="text-sm text-gray-900">{product.basePrice?.toLocaleString() || 0}원</div>
                        </td>
                        <td className="px-6 py-4 whitespace-nowrap">
                          <div className="text-sm text-gray-900">{product.stockQuantity || 0}개</div>
                        </td>
                        <td className="px-6 py-4 whitespace-nowrap">
                          <span className={`inline-flex px-2 py-1 text-xs font-semibold rounded-full ${
                            product.isActive ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'
                          }`}>
                            {product.isActive ? '판매중' : '비활성화'}
                          </span>
                        </td>
                        <td className="px-6 py-4 whitespace-nowrap text-sm font-medium">
                          <div className="flex space-x-2">
                            <button 
                              onClick={() => openEditModal(product)}
                              className="text-indigo-600 hover:text-indigo-900"
                            >
                              수정
                            </button>
                            <button 
                              onClick={() => handleDeactivateProduct(product.id)}
                              className="text-red-600 hover:text-red-900"
                            >
                              비활성화
                            </button>
                          </div>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
          </div>

          {/* Pagination */}
          <div className="mt-6 flex justify-center">
            <nav className="flex items-center space-x-2">
              <button 
                onClick={() => setCurrentPage(Math.max(1, currentPage - 1))}
                disabled={currentPage === 1}
                className="px-3 py-2 text-gray-500 hover:text-gray-700 disabled:opacity-50"
              >
                이전
              </button>
              {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => (
                <button
                  key={page}
                  onClick={() => setCurrentPage(page)}
                  className={`px-3 py-2 rounded-md ${
                    currentPage === page
                      ? 'bg-indigo-600 text-white'
                      : 'text-gray-500 hover:text-gray-700'
                  }`}
                >
                  {page}
                </button>
              ))}
              <button 
                onClick={() => setCurrentPage(Math.min(totalPages, currentPage + 1))}
                disabled={currentPage === totalPages}
                className="px-3 py-2 text-gray-500 hover:text-gray-700 disabled:opacity-50"
              >
                다음
              </button>
            </nav>
          </div>
        </main>
      </div>

             {/* Create Product Modal */}
       {showCreateModal && (
         <div className="fixed inset-0 bg-gray-600 bg-opacity-50 overflow-y-auto h-full w-full z-50">
           <div className="relative top-20 mx-auto p-5 border w-[600px] shadow-lg rounded-md bg-white max-h-[90vh] overflow-y-auto">
            <div className="mt-3">
              <h3 className="text-lg font-medium text-gray-900 mb-4">상품 추가</h3>
              <div className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700">상품명</label>
                  <input
                    type="text"
                    value={formData.name}
                    onChange={(e) => setFormData({...formData, name: e.target.value})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700">설명</label>
                  <textarea
                    value={formData.description}
                    onChange={(e) => setFormData({...formData, description: e.target.value})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                    rows={3}
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700">기본가격</label>
                  <input
                    type="number"
                    value={formData.basePrice}
                    onChange={(e) => setFormData({...formData, basePrice: Number(e.target.value)})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                  />
                </div>
                                 <div>
                   <label className="block text-sm font-medium text-gray-700">재고수량</label>
                   <input
                     type="number"
                     value={formData.stockQuantity}
                     onChange={(e) => setFormData({...formData, stockQuantity: Number(e.target.value)})}
                     className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                   />
                 </div>
                                  <div>
                    <label className="block text-sm font-medium text-gray-700 mb-2">상품 옵션</label>
                    
                    {/* 옵션 추가 폼 */}
                    <div className="mb-4 p-3 border border-gray-200 rounded-md bg-gray-50">
                      <div className="grid grid-cols-1 gap-2 mb-2">
                        <input
                          type="text"
                          placeholder="옵션명 (예: 색상, 사이즈)"
                          value={newOptionName}
                          onChange={(e) => setNewOptionName(e.target.value)}
                          className="w-full px-3 py-2 border border-gray-300 rounded-md text-sm"
                        />
                        <input
                          type="text"
                          placeholder="옵션값들 (쉼표로 구분)"
                          value={newOptionValues}
                          onChange={(e) => setNewOptionValues(e.target.value)}
                          className="w-full px-3 py-2 border border-gray-300 rounded-md text-sm"
                        />
                        <button
                          type="button"
                          onClick={addOption}
                          className="w-full px-4 py-2 bg-blue-600 text-white rounded-md text-sm hover:bg-blue-700"
                        >
                          옵션 추가
                        </button>
                      </div>
                      <p className="text-xs text-gray-500">예: 색상, 빨강,파랑,노랑</p>
                    </div>

                   {/* 기존 옵션들 */}
                   {options.map((option, optionIndex) => (
                     <div key={optionIndex} className="mb-3 p-3 border border-gray-200 rounded-md">
                       <div className="flex items-center justify-between mb-2">
                         <span className="font-medium text-sm">{option.name}</span>
                         <button
                           type="button"
                           onClick={() => removeOption(optionIndex)}
                           className="text-red-600 hover:text-red-800 text-sm"
                         >
                           삭제
                         </button>
                       </div>
                       <div className="flex flex-wrap gap-2">
                         {option.values.map((valueObj, valueIndex) => (
                           <div key={valueIndex} className="flex items-center gap-2 p-2 bg-blue-50 rounded-md">
                             <span className="text-sm font-medium">{valueObj.value}</span>
                             <input
                               type="number"
                               placeholder="가격"
                               value={valueObj.price}
                               onChange={(e) => updateOptionValuePrice(optionIndex, valueIndex, Number(e.target.value))}
                               className="w-20 px-2 py-1 text-xs border border-gray-300 rounded"
                             />
                             <span className="text-xs text-gray-500">원</span>
                             <button
                               type="button"
                               onClick={() => removeOptionValue(optionIndex, valueIndex)}
                               className="text-red-600 hover:text-red-800 text-xs"
                             >
                               ×
                             </button>
                           </div>
                         ))}
                       </div>
                     </div>
                   ))}
                 </div>
              </div>
              <div className="flex justify-end space-x-3 mt-6">
                                 <button
                   onClick={() => {
                     setShowCreateModal(false)
                     setOptions([])
                     setNewOptionName('')
                     setNewOptionValues('')
                   }}
                   className="px-4 py-2 text-gray-600 border border-gray-300 rounded-md hover:bg-gray-50"
                 >
                   취소
                 </button>
                <button
                  onClick={handleCreateProduct}
                  className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
                >
                  추가
                </button>
              </div>
            </div>
          </div>
        </div>
      )}

      {/* Edit Product Modal */}
      {showEditModal && selectedProduct && (
        <div className="fixed inset-0 bg-gray-600 bg-opacity-50 overflow-y-auto h-full w-full z-50">
          <div className="relative top-20 mx-auto p-5 border w-[600px] shadow-lg rounded-md bg-white max-h-[90vh] overflow-y-auto">
            <div className="mt-3">
              <h3 className="text-lg font-medium text-gray-900 mb-4">상품 수정</h3>
              <div className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-gray-700">상품명</label>
                  <input
                    type="text"
                    value={formData.name}
                    onChange={(e) => setFormData({...formData, name: e.target.value})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700">설명</label>
                  <textarea
                    value={formData.description}
                    onChange={(e) => setFormData({...formData, description: e.target.value})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                    rows={3}
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700">기본가격</label>
                  <input
                    type="number"
                    value={formData.basePrice}
                    onChange={(e) => setFormData({...formData, basePrice: Number(e.target.value)})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-gray-700">재고수량</label>
                  <input
                    type="number"
                    value={formData.stockQuantity}
                    onChange={(e) => setFormData({...formData, stockQuantity: Number(e.target.value)})}
                    className="mt-1 block w-full border border-gray-300 rounded-md px-3 py-2"
                  />
                </div>
                                 <div>
                   <label className="block text-sm font-medium text-gray-700 mb-2">상품 옵션</label>
                   
                   {/* 옵션 추가 폼 */}
                   <div className="mb-4 p-3 border border-gray-200 rounded-md bg-gray-50">
                     <div className="grid grid-cols-1 gap-2 mb-2">
                       <input
                         type="text"
                         placeholder="옵션명 (예: 색상, 사이즈)"
                         value={newOptionName}
                         onChange={(e) => setNewOptionName(e.target.value)}
                         className="w-full px-3 py-2 border border-gray-300 rounded-md text-sm"
                       />
                       <input
                         type="text"
                         placeholder="옵션값들 (쉼표로 구분)"
                         value={newOptionValues}
                         onChange={(e) => setNewOptionValues(e.target.value)}
                         className="w-full px-3 py-2 border border-gray-300 rounded-md text-sm"
                       />
                       <button
                         type="button"
                         onClick={addOption}
                         className="w-full px-4 py-2 bg-blue-600 text-white rounded-md text-sm hover:bg-blue-700"
                       >
                         옵션 추가
                       </button>
                     </div>
                     <p className="text-xs text-gray-500">예: 색상, 빨강,파랑,노랑</p>
                   </div>

                   {/* 기존 옵션들 */}
                   {options.map((option, optionIndex) => (
                     <div key={optionIndex} className="mb-3 p-3 border border-gray-200 rounded-md">
                       <div className="flex items-center justify-between mb-2">
                         <span className="font-medium text-sm">{option.name}</span>
                         <button
                           type="button"
                           onClick={() => removeOption(optionIndex)}
                           className="text-red-600 hover:text-red-800 text-sm"
                         >
                           삭제
                         </button>
                       </div>
                       <div className="flex flex-wrap gap-2">
                         {option.values.map((valueObj, valueIndex) => (
                           <div key={valueIndex} className="flex items-center gap-2 p-2 bg-blue-50 rounded-md">
                             <span className="text-sm font-medium">{valueObj.value}</span>
                             <input
                               type="number"
                               placeholder="가격"
                               value={valueObj.price}
                               onChange={(e) => updateOptionValuePrice(optionIndex, valueIndex, Number(e.target.value))}
                               className="w-20 px-2 py-1 text-xs border border-gray-300 rounded"
                             />
                             <span className="text-xs text-gray-500">원</span>
                             <button
                               type="button"
                               onClick={() => removeOptionValue(optionIndex, valueIndex)}
                               className="text-red-600 hover:text-red-800 text-xs"
                             >
                               ×
                             </button>
                           </div>
                         ))}
                       </div>
                     </div>
                   ))}
                 </div>
                <div>
                  <label className="flex items-center">
                    <input
                      type="checkbox"
                      checked={formData.isActive}
                      onChange={(e) => setFormData({...formData, isActive: e.target.checked})}
                      className="mr-2"
                    />
                    <span className="text-sm font-medium text-gray-700">활성화</span>
                  </label>
                </div>
              </div>
              <div className="flex justify-end space-x-3 mt-6">
                                 <button
                   onClick={() => {
                     setShowEditModal(false)
                     setOptions([])
                     setNewOptionName('')
                     setNewOptionValues('')
                   }}
                   className="px-4 py-2 text-gray-600 border border-gray-300 rounded-md hover:bg-gray-50"
                 >
                   취소
                 </button>
                <button
                  onClick={handleUpdateProduct}
                  className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
                >
                  수정
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  )
} 