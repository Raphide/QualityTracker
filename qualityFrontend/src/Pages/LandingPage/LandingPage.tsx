import React from "react";
import styles from "./LandingPage.module.scss";

const LandingPage = () => {
  return (
    <div>
      <div className={styles.top}>
        <h1>Landing</h1>
        <p>
          Welcome to the Product Quality Tracker Application. Navigate through
          the app using the links in the navigation bar
        </p>
      </div>
      <div className={styles.maintainance}>
        <h4>Planned maintainance</h4>
        <p>
          There will be planned Maintanance on DATE from TIME - TIME. During
          this time the tracker will be unavailable. For urgent reports and
          requests please email urgentemail@quality.rep
        </p>
      </div>
    </div>
  );
};

export default LandingPage;
