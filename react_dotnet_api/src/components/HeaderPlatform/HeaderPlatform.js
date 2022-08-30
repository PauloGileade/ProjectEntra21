import axios from "axios";
import { useState } from "react";
import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { dropdown } from "bootstrap";

function HeaderPlatform() {
  const baseUrl = "https://localhost:5001/api/Orders";
  const baseUrlCellEmployeer = "https://localhost:5001/api/CellEmployeers";

  const [data, setData] = useState([]);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalIncluirCellEmployeer, setModalIncluirCellEmployeer] =
    useState(false);
  const [modalFiltroByCell, setModalFiltroByCell] = useState(false);
  const [modalFiltroByRegister, setModalFiltroByRegister] = useState(false);
  const [modalFiltroByCodeProduct, setModalFiltroByCodeProduct] =
    useState(false);
  const [modalFiltroCellEmployeer, setModalFiltroCellEmployeer] =
    useState(false);
  const [dataDadosStart, setDataDadosStart] = useState("");
  const [dataDadosEnd, setDataDadosEnd] = useState("");

  const [orderselect, setOrderSelect] = useState({
    registerEmployeer: "",
    codeProduct: "",
    amountEnter: "",
  });

  const [cellEmployeerselect, setCellEmployeerSelect] = useState({
    codeCell: "",
    registerEmployeer: "",
  });

  const [orderByCellselect, setOrderByCellSelect] = useState({
    codeCell: "",
  });

  const [orderByRegisterselect, setOrderByRegisterSelect] = useState({
    register: "",
  });

  const [orderByCodeProductselect, setOrderByCodeProductSelect] = useState({
    register: "",
    codeProduct: "",
  });

  const [orderCellEmployeerselect, setOrderCellEmployeerSelect] = useState({
    codeCell: "",
  });

  const abrirFecharModalIncluir = () => {
    setModalIncluir(!modalIncluir);
  };

  const abrirFecharModalIncluirCellEmployeer = () => {
    setModalIncluirCellEmployeer(!modalIncluirCellEmployeer);
  };

  const abrirFecharModalFiltro = () => {
    setModalFiltroByCell(!modalFiltroByCell);
  };

  const abrirFecharModalFiltroByRegister = () => {
    setModalFiltroByRegister(!modalFiltroByRegister);
  };

  const abrirFecharModalFiltroByCodeProduct = () => {
    setModalFiltroByCodeProduct(!modalFiltroByCodeProduct);
  };

  const abrirFecharModalFiltroCellEmployeer = () => {
    setModalFiltroCellEmployeer(!modalFiltroCellEmployeer);
  };

  const setDataStart = (value) => {
    setDataDadosStart(value.split("/").reverse().join("-"));
  };

  const setDataEnd = (value) => {
    setDataDadosEnd(value.split("/").reverse().join("-"));
  };

  function redirect() {
    window.location.href =
      "/order/" + orderByCellselect.codeCell + "/" + dataDadosStart;
  }

  function redirectCellEmployeer() {
    window.location.href =
      "/cellemployeer/" +
      orderCellEmployeerselect.codeCell +
      "/" +
      dataDadosStart;
  }

  function redirectByRegister() {
    window.location.href =
      "/order/" +
      dataDadosStart +
      "/" +
      dataDadosEnd +
      "/" +
      orderByRegisterselect.register;
  }

  function redirectByCodeProduct() {
    window.location.href =
      "/order/" +
      orderByCodeProductselect.register +
      "/" +
      orderByCodeProductselect.codeProduct +
      "/" +
      dataDadosStart +
      "/" +
      dataDadosEnd;
  }

  const handleChange = (e) => {
    const { name, value } = e.target;
    setOrderSelect({
      ...orderselect,
      [name]: value,
    });
    console.log(orderselect);
  };

  const handleChangeCellEmployeer = (e) => {
    const { name, value } = e.target;
    setCellEmployeerSelect({
      ...cellEmployeerselect,
      [name]: value,
    });
    console.log(cellEmployeerselect);
  };

  const handleChangeGet = (e) => {
    const { name, value } = e.target;
    setOrderByCellSelect({
      ...orderByCellselect,
      [name]: value,
    });
    console.log(orderByCellselect);
  };

  const handleChangeGetByRegister = (e) => {
    const { name, value } = e.target;
    setOrderByRegisterSelect({
      ...orderByRegisterselect,
      [name]: value,
    });
    console.log(orderByRegisterselect);
  };

  const handleChangeGetByCodeProduct = (e) => {
    const { name, value } = e.target;
    setOrderByCodeProductSelect({
      ...orderByCodeProductselect,
      [name]: value,
    });
    console.log(orderByCodeProductselect);
  };

  const handleChangeGetCellEmployeer = (e) => {
    const { name, value } = e.target;
    setOrderCellEmployeerSelect({
      ...orderCellEmployeerselect,
      [name]: value,
    });
    console.log(orderCellEmployeerselect);
  };

  const pedidoPostOrder = () => {
    axios
      .post(baseUrl, orderselect)
      .then((response) => {
        console.log({
          response,
        });
        setData(data.concat(response.data));
        abrirFecharModalIncluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoPostCellEmployeer = () => {
    axios
      .post(baseUrlCellEmployeer, cellEmployeerselect)
      .then((response) => {
        console.log({
          response,
        });
        setData(data.concat(response.data));
        abrirFecharModalIncluirCellEmployeer();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-warning bg-warning">
        <div className="container-fluid">
          <a className="navbar-brand" href="/platform">
            <strong>Plataforma CTA</strong>
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarColor01"
            aria-controls="navbarColor01"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarColor01">
            <ul className="navbar-nav me-auto">
              <li className="nav-item">
                <a className="nav-link active" href="/dashboard">
                  <strong>Painel CTA</strong>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/employeer">
                  <strong>Funcionarios</strong>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/product">
                  <strong>Produtos</strong>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" href="/cell">
                  <strong>Celulas</strong>
                </a>
              </li>
              <li className="nav-item dropdown">
                <a
                  className="nav-link active dropdown"
                  data-bs-toggle="dropdown"
                  href="#"
                  role="button"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  <strong>Orderns</strong>
                </a>
                <div className="dropdown-menu">
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltro()}
                  >
                    Buscar Por Celula
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltroByRegister()}
                  >
                    Buscar Por Matricula
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltroByCodeProduct()}
                  >
                    Buscar Por Matricula/Produto
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalIncluir()}
                  >
                    Cadastrar Nova
                  </a>
                </div>
              </li>
              <li className="nav-item dropdown">
                <a
                  className="nav-link active dropdown"
                  data-bs-toggle="dropdown"
                  href="#"
                  role="button"
                  aria-haspopup="true"
                  aria-expanded="false"
                >
                  <strong>Operação</strong>
                </a>
                <div className="dropdown-menu">
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalFiltroCellEmployeer()}
                  >
                    Buscar Por Celula
                  </a>
                  <div className="dropdown-divider"></div>
                  <a
                    className="dropdown-item"
                    href="#"
                    onClick={() => abrirFecharModalIncluirCellEmployeer()}
                  >
                    Cadastrar Nova
                  </a>
                </div>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <Modal isOpen={modalIncluir}>
        <ModalHeader>Incluir Ordem</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Matricula Do Funcionario:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="registerEmployeer"
              onChange={handleChange}
            ></input>
            <label>Codigo Do Produto:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="codeProduct"
              onChange={handleChange}
            ></input>
            <label>Quantidade De Entrada:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="amountEnter"
              onChange={handleChange}
            ></input>
          </div>
        </ModalBody>

        <ModalFooter>
          <button className="btn btn-primary" onClick={() => pedidoPostOrder()}>
            {" "}
            Incluir
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalIncluir()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalIncluirCellEmployeer}>
        <ModalHeader>Incluir Nova</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Celula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="codeCell"
              onChange={handleChangeCellEmployeer}
            ></input>
            <label>Matricula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="registerEmployeer"
              onChange={handleChangeCellEmployeer}
            ></input>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => pedidoPostCellEmployeer()}
          >
            {" "}
            Incluir
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalIncluirCellEmployeer()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroByCell}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <label>Celula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="codeCell"
              onChange={handleChangeGet}
            ></input>
          </div>
          <div className="form-group">
            <label>Data:</label>
            <br />
            <input
              type="date"
              className="form-control"
              name="data"
              onChange={(e) => setDataStart(e.target.value)}
            ></input>
          </div>
        </ModalBody>

        <ModalFooter>
          <button className="btn btn-primary" onClick={() => redirect()}>
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltro()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroByRegister}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <div className="form-group">
              <label>Data Inicial:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataStart(e.target.value)}
              ></input>
            </div>
            <div className="form-group">
              <label>Data Final:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataEnd(e.target.value)}
              ></input>
            </div>
            <label>Matricula:</label>
            <br />
            <input
              type="text"
              className="form-control"
              name="register"
              onChange={handleChangeGetByRegister}
            ></input>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => redirectByRegister()}
          >
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltroByRegister()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroByCodeProduct}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <div className="form-group">
              <label>Matricula:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="register"
                onChange={handleChangeGetByCodeProduct}
              ></input>
              <label>Codigo Do Produto:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="codeProduct"
                onChange={handleChangeGetByCodeProduct}
              ></input>
              <label>Data Inicial:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataStart(e.target.value)}
              ></input>
            </div>
            <div className="form-group">
              <label>Data Final:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataEnd(e.target.value)}
              ></input>
            </div>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => redirectByCodeProduct()}
          >
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltroByCodeProduct()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalFiltroCellEmployeer}>
        <ModalHeader>Filtrar</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <div className="form-group">
              <label>Celula:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="codeCell"
                onChange={handleChangeGetCellEmployeer}
              ></input>
              <label>Data Inicial:</label>
              <br />
              <input
                type="date"
                className="form-control"
                name="data"
                onChange={(e) => setDataStart(e.target.value)}
              ></input>
            </div>
          </div>
        </ModalBody>

        <ModalFooter>
          <button
            className="btn btn-primary"
            onClick={() => redirectCellEmployeer()}
          >
            Buscar
          </button>
          <button
            className="btn btn-danger"
            onClick={() => abrirFecharModalFiltroCellEmployeer()}
          >
            Cancelar
          </button>
        </ModalFooter>
      </Modal>
    </div>
  );
}

export default HeaderPlatform;