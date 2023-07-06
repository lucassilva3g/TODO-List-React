import { Trash } from "@phosphor-icons/react";
import styles from "./Item.module.css";

interface ItemProps {
  todo: string;
  done: boolean;
  onDelete: () => void;
  onDone: () => void;
}

const Item = ({ todo, done, onDelete, onDone }: ItemProps) => {
  return (
    <div className={styles.item}>
      <label>
        <input type="checkbox" onClick={onDone} className={styles.checkbox} />
        <span></span>
      </label>
      <span className={done ? styles.done : ""}>{todo}</span>
      <Trash className={styles.trash} size={20} onClick={onDelete} />
    </div>
  );
};

export { Item };
