import {Clipboard} from "@phosphor-icons/react";
import styles from './Item.module.css'



const Item = () => {
  if (Item.length === 0) {
    return (
      <div className={styles.itensLista}>
        <p><Clipboard size={40} /></p>
        <p>Você ainda não tem tarefas cadastradas</p>
        <p>Crie tarefas e organize seus itens a fazer</p>
      </div>
    );
  }

  return <div>{}</div>;
};

export default Item;
