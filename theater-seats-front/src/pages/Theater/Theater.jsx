import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button } from '@mui/material';
import useAppContext from '../../hooks/useAppContext';

import './Theater.css';

export default function Theater() {
  const { selectedTheater, selectedTimeSlot, userName } = useAppContext();
  const [floor, setFloor] = useState(
    Array(selectedTheater.rows)
      .fill()
      .map((row) =>
        new Array(selectedTheater.columns).fill({
          occupied: false,
          name: '',
        })
      )
  );

  const handleSeatClick = (rowIndex, colIndex) => {
    floor[rowIndex][colIndex] = {
      occupied: true,
      name: userName,
    };
    setFloor([...floor]);
  };

  const submit = () => {
    let param = new Array();

    floor.map((row, rowIndex) => {
      row.map((column, columnIndex) => {
        if (floor[rowIndex][columnIndex].occupied === true) {
          param.push({
            timeSlotId: selectedTimeSlot,
            name: userName,
            row: rowIndex,
            column: columnIndex,
            theaterEntityId: selectedTheater.id,
          });
        }
      });
    });

    console.log(param);

    axios.put('https://localhost:5001/api/Reservations', param).then((res) => {
      alert('Saved successfully.');
    });
  };

  useEffect(() => {
    console.log(selectedTheater);
    selectedTheater.reservations.map(
      (reservation) =>
        (floor[reservation.row][reservation.column] = {
          occupied: true,
          name: reservation.name,
        })
    );
    setFloor([...floor]);
  }, []);

  return (
    <div className="Floor">
      <Button variant="contained" onClick={() => submit()}>
        Submit
      </Button>
      <table>
        <tbody>
          {floor.map((row, rowIndex) => {
            return (
              <tr key={rowIndex}>
                {row.map((col, colIndex) => {
                  return (
                    <td key={colIndex}>
                      <div
                        title={floor[rowIndex][colIndex].name}
                        onClick={() => handleSeatClick(rowIndex, colIndex)}
                        className={`Seat ${
                          floor[rowIndex][colIndex].occupied === true
                            ? 'Taken'
                            : 'Empty'
                        }`}
                      ></div>
                    </td>
                  );
                })}
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
}
