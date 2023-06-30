import React, { useState } from 'react';
import { Circle, Trash } from "@phosphor-icons/react";
import styles from "./Item.module.css";


interface ItemProps {
  todo: string;
  done: boolean;
  onDelete: () => void;
}

const Item = ({ todo, done, onDelete }: ItemProps) => {
 const handleDelete = () => {
    onDelete();
  };


  return (
    <div className={styles.item}>
      <Circle className={styles.circle} size={17} weight="fill"/>
      <span className={done ? styles.done : ""}>{todo}</span>

      <Trash className={styles.trash} size={20} onClick={handleDelete} />

    </div>
  );
};

export  {Item};
