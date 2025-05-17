export const BASE_URL = 'https://localhost:7243'

export function apiFetch(path, options) {
  return fetch(BASE_URL + path, options)
} 