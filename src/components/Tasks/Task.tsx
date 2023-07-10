import { Task } from "../../App";
import { Item } from "../Item/Item";
import { NoItem } from "../NoItem/NoItem";
import { useContext } from "react";
import { TodoContext } from "../../Contexts/TodoContext";
import styles from "./Task.module.css";

interface TasksProps {
  tasks: Task[];
}

const Tasks = ({ tasks }: TasksProps) => {
  const tasksDone = tasks.filter((task) => task.isComplete).length;

  const { handleDone, handleDelete } = useContext(TodoContext);

  return (
    <>
      <div className={styles.tasks}>
        <p className={styles.task1}>
          Tarefas criadas:{" "}
          <span className={styles.spanNum}>{tasks.length}</span>
        </p>
        <p className={styles.task2}>
          Tarefas concluídas:{" "}
          <span className={styles.spanNum}>
            {tasksDone > 0 ? `${tasksDone} de ${tasks.length}` : "0"}
          </span>
        </p>
      </div>

      {tasks.length === 0 ? (
        <NoItem />
      ) : (
        <div>
          {tasks.map((task) => (
            <Item
              key={task.id}
              done={task.isComplete}
              todo={task.name}
              onDelete={() => handleDelete(task.id)}
              onDone={() => handleDone(task.id)}
            />
          ))}
        </div>
      )}
    </>
  );
};

export { Tasks };
