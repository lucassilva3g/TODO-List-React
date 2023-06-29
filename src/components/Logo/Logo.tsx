import logo from "../../assets/logo.svg";
import styles from "./Logo.module.css";

const Logo = () => {
  return (
    <div>
      <img className={styles.logo} src={logo} alt="Logo da aplicação" />
    </div>
  );
};

export { Logo };
