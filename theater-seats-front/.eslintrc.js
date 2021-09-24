module.exports = {
  extends: [
    'airbnb',
    'airbnb/hooks',
    'plugin:jest/recommended',
    'plugin:prettier/recommended',
  ],
  ignorePatterns: ['**/node_modules/'],
  rules: {
    'prettier/prettier': 'off',
    'react/jsx-props-no-spreading': 'off',
    'no-undef': ['error', { ignore: ['./src/index.jsx'] }],
  },
};
