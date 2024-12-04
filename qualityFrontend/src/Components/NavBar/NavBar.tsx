import React from 'react'
import { NavLink } from 'react-router-dom'
import styles from "./NavBar.module.scss"

const NavBar = () => {
  return (
    <div className={styles.bar}>
      <nav>
        <NavLink className={styles.link} to="/">Home</NavLink>
        <NavLink className={styles.link} to="/cases">Cases</NavLink>
        <NavLink className={styles.link} to="/cases/create">Enter a new Case</NavLink>
      </nav>
    </div>
  )
}

export default NavBar