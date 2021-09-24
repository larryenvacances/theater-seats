import * as React from 'react';

import './Theater.css';

export default function Theater() {
  let floor = Array(4)
    .fill(false)
    .map((row) => new Array(4).fill(false));

  return (
    <div className="Floor">
      <table>
        {floor.map((row, rowIndex) => {
          return (
            <tr>
              {row.map((col, colIndex) => {
                return (
                  <td className="Seat">
                    {rowIndex}, {colIndex}
                  </td>
                );
              })}
            </tr>
          );
        })}
      </table>
    </div>
  );
}
