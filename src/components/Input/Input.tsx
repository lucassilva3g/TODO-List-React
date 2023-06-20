import { PlusCircle } from "@phosphor-icons/react";
import styles from './Input.module.css'


const Input = () => {
  return (
    <div className={styles.elem}>
      <input type="text" placeholder="Adicione uma nova tarefa" />
      <button>
        Criar <PlusCircle size={11} />{" "}
      </button>
    </div>
  );
};

export { Input };
