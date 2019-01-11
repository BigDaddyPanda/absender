// import config from 'config';
import { authHeader } from '../_helpers';

export const userService = {
    // dedicated_services
};


// prefixed function name with underscore because delete is a reserved word in javascript
// function main_definition_of_the_service(id) {
//     const requestOptions = {
//         method: 'DELETE',
//         headers: authHeader()
//     };

//     return fetch(`localhost/users/${id}`, requestOptions).then(handleResponse);
// }

// handling response

// function handleResponse(response) {
//     return response.text().then(text => {
//         const data = text && JSON.parse(text);
//         if (!response.ok) {
//             if (response.status === 401) {
//                 // auto logout if 401 response returned from api
//                 logout();
//                 window.location.reload(true);
//             }

//             const error = (data && data.message) || response.statusText;
//             return Promise.reject(error);
//         }

//         return data;
//     });
// }