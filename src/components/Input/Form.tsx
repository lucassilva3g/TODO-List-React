import { ChangeEvent } from "react";
import { PlusCircle } from "@phosphor-icons/react";
import styles from "./Form.module.css";

interface InputProps {
  onCreatNewTask: () => void;
  onInputChange: (event: ChangeEvent<HTMLInputElement>) => void;
  taskValue: string;
  isButtonDisabled: boolean;
}

const Form = ({
  onCreatNewTask,
  onInputChange,
  taskValue,
  isButtonDisabled,
}: InputProps) => {
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (taskValue.trim() !== "") {
      onCreatNewTask();
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className={styles.elements}>
        <input
          className={styles.addTask}
          type="text"
          placeholder="Adicione uma nova tarefa"
          value={taskValue}
          onChange={onInputChange}
        />
        <button className={styles.buttonCreate} disabled={isButtonDisabled}>
          Criar <PlusCircle size={15} />
        </button>
      </div>
    </form>
  );
};

export { Form };
