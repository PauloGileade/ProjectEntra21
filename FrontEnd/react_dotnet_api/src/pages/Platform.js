import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";

function Platform() {
  return (
    <div>
      <HeaderPlatform />
      <main className="main__global">
        <div className="main__container">
          <div className="main__title">
            <div className="main__greeting">
              <h1>Olá</h1>
              <p>Bem vindo a plataforma de controle</p>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
}

export default Platform;
