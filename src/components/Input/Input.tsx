import { ChangeEvent } from "react";
import { PlusCircle } from "@phosphor-icons/react";
import styles from "./Input.module.css";

interface InputProps {
  onCreatNewTask: () => void;
  onInputChange: (event: ChangeEvent<HTMLInputElement>) => void;
  taskValue: string;
  isButtonDisabled: boolean;
}

const Input = ({
  onCreatNewTask,
  onInputChange,
  taskValue,
  isButtonDisabled,
}: InputProps) => {
  const handleClick = () => {
    if (taskValue.trim() !== "") {
      onCreatNewTask();
    }
  };

  return (
    <div className={styles.elem}>
      <input className={styles.addTask}
        type="text"
        placeholder="Adicione uma nova tarefa"
        value={taskValue}
        onChange={onInputChange}
      />
      <button className={styles.buttonCreate} disabled={isButtonDisabled} onClick={handleClick}>
        Criar <PlusCircle size={11} />
      </button>
    </div>
  );
};

export { Input };
