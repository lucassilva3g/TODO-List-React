import { PlusCircle } from "@phosphor-icons/react";
import styles from "./Input.module.css";

interface InputProps {
  onCreatNewTask: () => void;
  onInputChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  taskValue: string;
}

const Input = ({ onCreatNewTask, onInputChange, taskValue }: InputProps) => {
  const handleClick = () => {
    if (taskValue.trim() !== "") {
      onCreatNewTask();
    }
  };

  return (
    <div className={styles.elem}>
      <input
        type="text"
        placeholder="Adicione uma nova tarefa"
        value={taskValue}
        onChange={onInputChange}
      />
      <button onClick={handleClick}>
        Criar <PlusCircle size={11} />
      </button>
    </div>
  );
};

export { Input };
