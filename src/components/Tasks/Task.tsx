import { Task } from "../../App";
import { Item } from "../Item/Item";
import { NoItem } from "../NoItem/NoItem";
import styles from "./Task.module.css";

interface TasksProps {
  tasks: Task[];
  setTasks: React.Dispatch<React.SetStateAction<Task[]>>;
}

const Tasks = ({ tasks, setTasks }: TasksProps) => {
  const tasksDone = tasks.filter((task) => task.isComplete).length;

  const handleDelete = (taskId: number) => {
    setTasks(tasks.filter((taskItem) => taskItem.id !== taskId));
  };

  const handleDone = (taskId: number) => {
    setTasks((prevTasks) =>
      prevTasks.map((task) =>
        task.id === taskId ? { ...task, isComplete: !task.isComplete } : task
      )
    );
  };

  return (
    <>
      <div className={styles.tarefas}>
        <p className={styles.tarefa1}>
          Tarefas criadas:{" "}
          <span className={styles.spanNum}>{tasks.length}</span>
        </p>
        <p className={styles.tarefa2}>
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
