const Logo = () => {
  return (
    <div>
      <img
        src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTu-9J30x4uoS8VJDYOcpc4EaYB0Rn06qxRJCErf-1KNccp_ZYXUdNHlzS32zzbb3eRdio&usqp=CAU"
        alt=""
      />
    </div>
  );
};
const InputBut = () => {
  return (
    <div className="elem">
      <input type="text" placeholder="Adicione uma nova tarefa" />
      <button>Criar + </button>
    </div>
  );
};

export { Logo, InputBut };
