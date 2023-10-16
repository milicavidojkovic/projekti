import React, { Children } from 'react'
import { Outlet } from 'react-router-dom'
import NavBarSaradnik from './NavBarSaradnik'

export default function SaradnikLayout() {
  return (
    <div>
      <NavBarSaradnik></NavBarSaradnik>
      <Outlet/>
    </div>
  )
}
