import Navbar from './Navbar'

export default function UserLayout({ children }) {
  return (
    <div>
      <Navbar />
      {children}
    </div>
  )
} 