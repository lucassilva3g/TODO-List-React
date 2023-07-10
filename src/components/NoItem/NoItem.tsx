import { Clipboard } from "@phosphor-icons/react";
import styles from "./NoItem.module.css";

const NoItem = () => {
  return (
    <>
    <div className={styles.line}></div>
    <div className={styles.lineItems}>
      <p>
        <Clipboard size={40} />
      </p>
      <p className={styles.noTasks}>Você aindaa não tem tarefas cadastradas</p>
      <p className={styles.create}>Crie tarefas e organize seus itens a fazer</p>
    </div>
    </>
  );
};

export { NoItem };
