import { Trash } from "@phosphor-icons/react";
import styles from "./Item.module.css";


interface ItemProps {
  todo: string;
  done: boolean;
  onDelete: () => void;
}

const Item = ({ todo, done, onDelete }: ItemProps) => {
  return (
    <div className={styles.item}>
      {/* <Checkbox size={20} checked={done} /> */}
      <span className={done ? styles.done : ""}>{todo}</span>
      <Trash size={20} onClick={onDelete} />
    </div>
  );
};

export  {Item};
