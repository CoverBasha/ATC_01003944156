import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import Login from './pages/Login'
import Home from './pages/Home'
import EventDetails from './pages/EventDetails'
import Congrats from './pages/Congrats'
import Admin from './pages/Admin'
import Register from './pages/Register'

function DefaultRedirect() {
  const hasToken = !!localStorage.getItem('token')
  return <Navigate to={hasToken ? '/home' : '/login'} replace />
}

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/" element={<DefaultRedirect />} />
        <Route path="/home" element={<Home />} />
        <Route path="/event/:id" element={<EventDetails />} />
        <Route path="/congrats" element={<Congrats />} />
        <Route path="/admin" element={<Admin />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
