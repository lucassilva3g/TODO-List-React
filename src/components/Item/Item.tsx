import { Trash } from "@phosphor-icons/react";
import styles from "./Item.module.css";

interface ItemProps {
  todo: string;
  done: boolean;
  onDelete: () => void;
  onToggle: () => void;
}

const Item = ({ todo, done, onDelete, onToggle }: ItemProps) => {
  return (
    <div className={styles.item}>
      <input type="checkbox" onClick={onToggle} />
      <span className={done ? styles.done : ""}>{todo}</span>
      <Trash className={styles.trash} size={20} onClick={onDelete} />
    </div>
  );
};

export { Item };
