import {axiosBase as axios} from './AxiosConfig';

export const Create = async(user) =>{
    try{
        const response = await axios.post("security/createuser", user);
        console.log("crearUsuario",response);
    }
    catch(error){
        console.log(error);
        return error;
    }
}