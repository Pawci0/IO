const axios = require('axios');
const oauth = require('axios-oauth-client');
const getOwnerCredentials = oauth.client(axios.create(), {
  url: 'http://localhost:53026/token',
  grant_type: 'password',
  username: '1234',
  password: 'adminnimda',
});
 
export const auth = async () => await getOwnerCredentials();