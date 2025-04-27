import './App.css'
import Login from './pages/Login/Login'
import Register from './pages/Register/Register'

import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'

function App() {

  return (
   <Router>
      <Routes>
        <Route path='/' element={<Login/>}></Route>
        <Route path='/register' element={<Register/>}></Route>
      </Routes>
   </Router>
  )
}

export default App
