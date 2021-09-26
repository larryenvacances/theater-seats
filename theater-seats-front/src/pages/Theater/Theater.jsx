import React, { useState, useEffect } from 'react';
import axios from 'axios';
import useAppContext from '../../hooks/useAppContext';

import './Theater.css';

export default function Theater() {
  const { selectedTheater } = useAppContext();
  const [floor, setFloor] = useState(
    Array(selectedTheater.rows)
      .fill()
      .map((row) => new Array(selectedTheater.columns).fill(false))
  );

  let handleSeatClick = (rowIndex, colIndex) => {
    floor[rowIndex][colIndex] = true;
    setFloor([...floor]);
  };

  useEffect(() => {
    console.log(selectedTheater);
    // axios.get('https://localhost:5001/api/Theaters', { params }).then((res) => {
    //   setMovies(res.data);
    //   console.log(res.data);
    // });
  }, []);

  return (
    <div className="Floor">
      <table>
        <tbody>
          {floor.map((row, rowIndex) => {
            return (
              <tr key={rowIndex}>
                {row.map((col, colIndex) => {
                  return (
                    <td key={colIndex}>
                      <div
                        onClick={() => handleSeatClick(rowIndex, colIndex)}
                        className={`Seat ${
                          floor[rowIndex][colIndex] === true ? 'Taken' : 'Empty'
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
