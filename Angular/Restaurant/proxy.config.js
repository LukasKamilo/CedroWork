const proxy = [
    {
      context: '/api',
      target: 'http://localhost:49398',
      pathRewrite: {'^/api' : ''}
    }
  ];
  
  module.exports = proxy;