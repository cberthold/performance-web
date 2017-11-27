import auth from './auth';

export default function fetchapi(input: RequestInfo, init?: RequestInit): Promise<any> {

    var token = auth.getAccessToken();
    var requestInit = init ? init : { headers: {} };

    requestInit.headers = {
        ...requestInit.headers,
        Authorization: `Bearer ${token}`,
    };

    return fetch(input, requestInit);
}