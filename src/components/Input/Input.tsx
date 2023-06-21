import React, { useState } from "react";
import { PlusCircle } from "@phosphor-icons/react";
import styles from "./Input.module.css";

const Input = () => {
  const [newTask, setNewTask] = useState("");

const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewTask(event.target.value);
  };

  const handleCreateNewTask = () => {
    alert(newTask)
    setNewTask("");
  };

  return (
    <div className={styles.elem}>
      <input
        type="text"
        placeholder="Adicione uma nova tarefa"
        value={newTask}
        onChange={handleInputChange}
      />
      <button onClick={handleCreateNewTask}>
        Criar <PlusCircle size={11} />
      </button>

    </div>
  );
};

export { Input };
