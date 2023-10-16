import React, { useState } from 'react';

const PieChart = ({ values }) => {
  const [activeIndex, setActiveIndex] = useState(null);

  const handleMouseEnter = (index) => {
    setActiveIndex(index);
  };

  const handleMouseLeave = () => {
    setActiveIndex(null);
  };

  if (!values || !Array.isArray(values)) {
    return <div>No data available</div>;
  }

  const totalPercentage = values.reduce((total, { percentage }) => total + percentage, 0);

  return (
    <div>
      <svg width="200" height="200">
        {values.map(({ color, percentage, label }, index) => {
          const startAngle = index === 0 ? 0 : values.slice(0, index).reduce((total, { percentage }) => total + percentage, 0);
          const endAngle = (startAngle + percentage) % 100;

          const startX = Math.cos((startAngle / 100) * 2 * Math.PI) * 80 + 100;
          const startY = Math.sin((startAngle / 100) * 2 * Math.PI) * 80 + 100;
          const endX = Math.cos((endAngle / 100) * 2 * Math.PI) * 80 + 100;
          const endY = Math.sin((endAngle / 100) * 2 * Math.PI) * 80 + 100;

          const isHovered = index === activeIndex;

          return (
            <g key={index}>
              <path
                d={`M 100 100 L ${startX} ${startY} A 80 80 0 ${percentage > 50 ? 1 : 0} 1 ${endX} ${endY} Z`}
                fill={color}
                onMouseEnter={() => handleMouseEnter(index)}
                onMouseLeave={handleMouseLeave}
              />
              {isHovered && (
                <text
                  x="100"
                  y="110"
                  textAnchor="middle"
                  fill="whitesmoke"
                  fontWeight="bold"
                  style={{ pointerEvents: 'none' }}
                >
                  {label}
                </text>
              )}
            </g>
          );
        })}
      </svg>
    </div>
  );
};

export default PieChart;
