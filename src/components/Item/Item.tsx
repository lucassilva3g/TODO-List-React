import { Trash } from "@phosphor-icons/react";
import styles from "./Item.module.css";

interface ItemProps {
  todo: string;
  done: boolean;
  onDelete: () => void;
  onDone: () => void;
  id: number;
}

const Item = ({ todo, done, onDelete, onDone, id }: ItemProps) => {
  return (
    <div className={styles.item}>
      <div>
        <label>
          <input value={id} type="checkbox" onClick={onDone} className={styles.checkbox} />
          <span></span>
        </label>
      </div>
      <div>
        <p className={done ? styles.done : ""}>{todo}</p>
      </div>
      <div>
        <Trash className={styles.trash} size={20} onClick={onDelete} />
      </div>
    </div>
  );
};

export { Item };
