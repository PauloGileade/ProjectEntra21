import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import {
  Button,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Table,
  Row,
} from "reactstrap";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";
import { useParams } from "react-router-dom";

function TotalPartial() {
  const [data, setData] = useState([]);
  const baseUrlTotalPartial = "https://192.168.1.7:5001/api/TotalPartials";

  let phaseCell = useParams().phaseCell;
  let codeCell = useParams().codeCell;

  const GetTotalPartialByCell = async () => {
    await axios
      .get(baseUrlTotalPartial + "/" + phaseCell + "/" + codeCell)
      .then((response) => {
        console.log(response);
        setData([response.data]);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    GetTotalPartialByCell();
  }, []);

  return (
    <div>
      <HeaderPlatform />
      <main className="container">
        <br />
        <Row md="12" sm="2" xs="1">
          <Table bordered hover responsive size="sm">
            <thead className="table__order">
              <tr align="center">
                <th>Celula</th>
                <th>Fase</th>
                <th>Saida</th>

              </tr>
            </thead>
            <tbody>
              {data.map((totalPartial) => (
                <tr
                  className="table__painel"
                  align="center"
                  key={totalPartial.codeCell}
                >
                  <td>{totalPartial.codeCell}</td>
                  <td>{totalPartial.phase}</td>
                  <td>{totalPartial.totalPhaseExit}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Row>
      </main>
    </div>
  );
}

export default TotalPartial;
