import { Link, useNavigate } from 'react-router-dom'
import logo from '../assets/Eventatos.png'

export default function Navbar() {
  const navigate = useNavigate()
  function handleLogout() {
    localStorage.removeItem('token')
    navigate('/login')
  }
  return (
    <nav style={{ display: 'flex', alignItems: 'center', gap: 20, padding: 10, borderBottom: '1px solid #eee' }}>
      <Link to="/home">
        <img src={logo} alt="Eventatos" style={{ height: 40 }} />
      </Link>
      <button>Events</button>
      <div style={{ flex: 1 }} />
      <button onClick={handleLogout}>Logout</button>
    </nav>
  )
} 