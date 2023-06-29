import { Clipboard } from "@phosphor-icons/react";
import styles from "./NoItem.module.css";

const NoItem = () => {

    return (
      <div className={styles.itensLista}>
        <p>
          <Clipboard size={40} />
        </p>
        <p>Você ainda não tem tarefas cadastradas</p>
        <p>Crie tarefas e organize seus itens a fazer</p>
      </div>
    );



};

export {NoItem};
