import { useEffect, useState } from 'react'
import UserLayout from '../components/UserLayout'
import { useNavigate } from 'react-router-dom'
import { apiFetch } from '../api'

export default function Home() {
  const navigate = useNavigate()
  const [events, setEvents] = useState([])
  const [bookings, setBookings] = useState([])

  useEffect(() => {
    if (!localStorage.getItem('token')) {
      navigate('/login')
    }
  }, [navigate])

  useEffect(() => {
    async function fetchData() {
      const res = await apiFetch('/api/Events')
      const data = await res.json()
      setEvents(data)
      const bookingsRes = await apiFetch('/api/Bookings', {
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') }
      })
      const bookingsData = await bookingsRes.json()
      setBookings(bookingsData)
    }
    fetchData()
  }, [])

  function isBooked(eventId) {
    return bookings.some(b => b.eventId === eventId)
  }

  async function handleBook(eventId) {
    const res = await apiFetch('/api/Bookings/' + eventId, {
      method: 'POST',
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('token') }
    })
    if (res.ok) {
      const booking = await res.json()
      setBookings([...bookings, booking])
    }
  }

  return (
    <UserLayout>
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(300px, 1fr))', gap: 20, margin: 20 }}>
        {events.map(e => (
          <div key={e.id} style={{ border: '1px solid #eee', borderRadius: 8, padding: 16 }}>
            <img src={e.imageURL} alt={e.name} style={{ width: '100%', height: 180, objectFit: 'cover', borderRadius: 8 }} />
            <h3>{e.name}</h3>
            <div>{e.date}</div>
            <div>{e.venue}</div>
            <div>{e.price} EGP</div>
            {isBooked(e.id) ? (
              <div>Booked</div>
            ) : (
              <button onClick={() => handleBook(e.id)}>Book Now</button>
            )}
          </div>
        ))}
      </div>
    </UserLayout>
  )
}
