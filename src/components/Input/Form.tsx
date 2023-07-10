import { PlusCircle } from "@phosphor-icons/react";
import { useContext } from "react";
import { TodoContext } from "../../Contexts/TodoContext";
import styles from "./Form.module.css";

interface InputProps {
  taskValue: string;
  isButtonDisabled: boolean;
}

const Form = ({ taskValue, isButtonDisabled }: InputProps) => {
  const { handleCreateNewTask, handleInputChange } = useContext(TodoContext);

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (taskValue.trim() !== "") {
      handleCreateNewTask();
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
          onChange={handleInputChange}
        />
        <button className={styles.buttonCreate} disabled={isButtonDisabled}>
          Criar <PlusCircle size={15} />
        </button>
      </div>
    </form>
  );
};

export { Form };
