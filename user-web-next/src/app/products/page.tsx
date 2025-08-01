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

const fetchActiveProducts = async (page: number = 1, pageSize: number = 12) => {
  try {
    const response = await fetch(`${API_BASE_URL}/product/active?page=${page}&pageSize=${pageSize}`)
    if (!response.ok) {
      throw new Error('상품 목록을 불러오는데 실패했습니다.')
    }
    return await response.json()
  } catch (error) {
    console.error('상품 목록 조회 오류:', error)
    throw error
  }
}

const searchProducts = async (searchTerm: string, page: number = 1, pageSize: number = 12) => {
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

export default function ProductsPage() {
  const [products, setProducts] = useState<Product[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)
  const [searchTerm, setSearchTerm] = useState('')
  const [currentPage, setCurrentPage] = useState(1)
  const [totalPages, setTotalPages] = useState(1)
  const [sortBy, setSortBy] = useState('')

  // 상품 목록 조회
  const loadProducts = async () => {
    try {
      setLoading(true)
      setError(null)
      const data = await fetchActiveProducts(currentPage, 12)
      setProducts(data)
      // 실제 API에서 페이지 정보를 받아와야 함
      setTotalPages(Math.ceil(data.length / 12) || 1)
    } catch (err) {
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
      const data = await searchProducts(searchTerm, currentPage, 12)
      setProducts(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : '상품 검색에 실패했습니다.')
    } finally {
      setLoading(false)
    }
  }

  // 정렬된 상품 목록
  const sortedProducts = [...products].sort((a, b) => {
    switch (sortBy) {
      case 'low':
        return a.basePrice - b.basePrice
      case 'high':
        return b.basePrice - a.basePrice
      case 'new':
        return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
      default:
        return 0
    }
  })

  // 초기 로드
  useEffect(() => {
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
    <div className="min-h-screen bg-gray-50">
      {/* Header */}
      <header className="bg-white shadow-sm">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between items-center py-6">
            <div className="flex items-center">
              <Link href="/" className="text-2xl font-bold text-gray-900">
                AGL Shopping Mall
              </Link>
            </div>
            <nav className="hidden md:flex space-x-8">
              <Link href="/products" className="text-indigo-600 font-medium">
                상품
              </Link>
              <Link href="/cart" className="text-gray-500 hover:text-gray-900">
                장바구니
              </Link>
              <Link href="/orders" className="text-gray-500 hover:text-gray-900">
                주문내역
              </Link>
              <Link href="/login" className="text-gray-500 hover:text-gray-900">
                로그인
              </Link>
            </nav>
          </div>
        </div>
      </header>

      {/* Main Content */}
      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="mb-8">
          <h1 className="text-3xl font-bold text-gray-900">상품 목록</h1>
          <p className="mt-2 text-gray-600">다양한 상품들을 확인해보세요.</p>
        </div>

        {/* Error Message */}
        {error && (
          <div className="mb-4 bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded">
            {error}
          </div>
        )}

        {/* Search and Filters */}
        <div className="mb-8">
          <div className="flex flex-col sm:flex-row gap-4">
            <div className="flex-1">
              <input
                type="text"
                placeholder="상품명으로 검색..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500"
              />
            </div>
            <div className="sm:w-48">
              <select
                value={sortBy}
                onChange={(e) => setSortBy(e.target.value)}
                className="w-full px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500"
              >
                <option value="">정렬</option>
                <option value="low">낮은 가격순</option>
                <option value="high">높은 가격순</option>
                <option value="new">최신순</option>
              </select>
            </div>
          </div>
        </div>

        {/* Products Grid */}
        {loading ? (
          <div className="flex justify-center items-center py-12">
            <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-indigo-600"></div>
          </div>
        ) : (
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6">
            {sortedProducts.map((product) => (
              <div key={product.id} className="bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition-shadow">
                <div className="aspect-w-1 aspect-h-1 w-full">
                  <div className="w-full h-48 bg-gray-200 flex items-center justify-center">
                    <span className="text-gray-500">이미지</span>
                  </div>
                </div>
                <div className="p-4">
                  <div className="flex items-center justify-between mb-2">
                    <span className="text-sm text-indigo-600 font-medium">
                      {product.stockQuantity > 0 ? '재고있음' : '품절'}
                    </span>
                    <span className="text-lg font-bold text-gray-900">
                      {product.basePrice.toLocaleString()}원
                    </span>
                  </div>
                  <h3 className="text-lg font-semibold text-gray-900 mb-2">{product.name}</h3>
                  <p className="text-gray-600 text-sm mb-4 line-clamp-2">{product.description}</p>
                  <div className="flex space-x-2">
                    <button 
                      disabled={product.stockQuantity === 0}
                      className={`flex-1 py-2 px-4 rounded-md transition-colors ${
                        product.stockQuantity === 0
                          ? 'bg-gray-300 text-gray-500 cursor-not-allowed'
                          : 'bg-indigo-600 text-white hover:bg-indigo-700'
                      }`}
                    >
                      {product.stockQuantity === 0 ? '품절' : '장바구니 추가'}
                    </button>
                    <Link
                      href={`/products/${product.id}`}
                      className="flex-1 bg-gray-100 text-gray-700 py-2 px-4 rounded-md hover:bg-gray-200 transition-colors text-center"
                    >
                      상세보기
                    </Link>
                  </div>
                </div>
              </div>
            ))}
          </div>
        )}

        {/* Empty State */}
        {!loading && sortedProducts.length === 0 && (
          <div className="text-center py-12">
            <div className="text-gray-500 text-lg mb-2">상품을 찾을 수 없습니다.</div>
            <div className="text-gray-400 text-sm">다른 검색어를 시도해보세요.</div>
          </div>
        )}

        {/* Pagination */}
        {!loading && sortedProducts.length > 0 && (
          <div className="mt-8 flex justify-center">
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
        )}
      </main>
    </div>
  )
} 