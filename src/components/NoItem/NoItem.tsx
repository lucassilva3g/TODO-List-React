import { Clipboard } from "@phosphor-icons/react";
import styles from "./NoItem.module.css";

const NoItem = () => {
  return (
    <>
    <div className={styles.linha}></div>
    <div className={styles.itensLista}>
      <p>
        <Clipboard size={40} />
      </p>
      <p className={styles.semTarefas}>Você ainda não tem tarefas cadastradas</p>
      <p className={styles.crie}>Crie tarefas e organize seus itens a fazer</p>
    </div>
    </>
  );
};

export { NoItem };
