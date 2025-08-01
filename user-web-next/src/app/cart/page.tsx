import Link from 'next/link'

// 임시 장바구니 데이터
const cartItems = [
  {
    id: 1,
    productId: 1,
    name: '프리미엄 노트북',
    price: 1200000,
    quantity: 1,
    image: '/api/placeholder/100/100'
  },
  {
    id: 2,
    productId: 3,
    name: '무선 이어폰',
    price: 150000,
    quantity: 2,
    image: '/api/placeholder/100/100'
  }
]

export default function CartPage() {
  const totalPrice = cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0)

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
              <Link href="/products" className="text-gray-500 hover:text-gray-900">
                상품
              </Link>
              <Link href="/cart" className="text-indigo-600 font-medium">
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
          <h1 className="text-3xl font-bold text-gray-900">장바구니</h1>
          <p className="mt-2 text-gray-600">선택한 상품들을 확인하고 주문하세요.</p>
        </div>

        {cartItems.length === 0 ? (
          <div className="text-center py-12">
            <div className="text-gray-400 mb-4">
              <svg className="mx-auto h-12 w-12" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 11V7a4 4 0 00-8 0v4M5 9h14l1 12H4L5 9z" />
              </svg>
            </div>
            <h3 className="text-lg font-medium text-gray-900 mb-2">장바구니가 비어있습니다</h3>
            <p className="text-gray-500 mb-6">상품을 추가해보세요.</p>
            <Link
              href="/products"
              className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700"
            >
              상품 보기
            </Link>
          </div>
        ) : (
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
            {/* Cart Items */}
            <div className="lg:col-span-2">
              <div className="bg-white rounded-lg shadow">
                <div className="px-6 py-4 border-b border-gray-200">
                  <h2 className="text-lg font-medium text-gray-900">상품 목록</h2>
                </div>
                <div className="divide-y divide-gray-200">
                  {cartItems.map((item) => (
                    <div key={item.id} className="px-6 py-4">
                      <div className="flex items-center">
                        <div className="flex-shrink-0 w-16 h-16 bg-gray-200 rounded-md flex items-center justify-center">
                          <span className="text-gray-500 text-xs">이미지</span>
                        </div>
                        <div className="ml-4 flex-1">
                          <h3 className="text-lg font-medium text-gray-900">{item.name}</h3>
                          <p className="text-gray-500">{item.price.toLocaleString()}원</p>
                        </div>
                        <div className="flex items-center space-x-2">
                          <button className="w-8 h-8 border border-gray-300 rounded-md flex items-center justify-center hover:bg-gray-50">
                            -
                          </button>
                          <span className="w-12 text-center">{item.quantity}</span>
                          <button className="w-8 h-8 border border-gray-300 rounded-md flex items-center justify-center hover:bg-gray-50">
                            +
                          </button>
                        </div>
                        <div className="ml-4 text-right">
                          <p className="text-lg font-medium text-gray-900">
                            {(item.price * item.quantity).toLocaleString()}원
                          </p>
                          <button className="text-sm text-red-600 hover:text-red-800">삭제</button>
                        </div>
                      </div>
                    </div>
                  ))}
                </div>
              </div>
            </div>

            {/* Order Summary */}
            <div className="lg:col-span-1">
              <div className="bg-white rounded-lg shadow">
                <div className="px-6 py-4 border-b border-gray-200">
                  <h2 className="text-lg font-medium text-gray-900">주문 요약</h2>
                </div>
                <div className="px-6 py-4 space-y-4">
                  <div className="flex justify-between">
                    <span className="text-gray-600">상품 금액</span>
                    <span className="text-gray-900">{totalPrice.toLocaleString()}원</span>
                  </div>
                  <div className="flex justify-between">
                    <span className="text-gray-600">배송비</span>
                    <span className="text-gray-900">무료</span>
                  </div>
                  <div className="border-t border-gray-200 pt-4">
                    <div className="flex justify-between">
                      <span className="text-lg font-medium text-gray-900">총 결제금액</span>
                      <span className="text-lg font-bold text-gray-900">{totalPrice.toLocaleString()}원</span>
                    </div>
                  </div>
                  <button className="w-full bg-indigo-600 text-white py-3 px-4 rounded-md hover:bg-indigo-700 transition-colors">
                    주문하기
                  </button>
                </div>
              </div>
            </div>
          </div>
        )}
      </main>
    </div>
  )
} 