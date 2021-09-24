import React, { useState } from 'react';

import './Theater.css';

export default function Theater() {
  const [floor, setFloor] = useState(
    Array(4)
      .fill()
      .map((row) => new Array(4).fill(false))
  );

  let handleSeatClick = (rowIndex, colIndex) => {
    floor[rowIndex][colIndex] = !floor[rowIndex][colIndex];
    setFloor(floor);
  };

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
