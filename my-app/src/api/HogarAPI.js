import {axiosBase as axios} from './AxiosConfig';

export const getAll = async () =>{
    try{
        const response = await axios.get("Hogar/GetAll");
        return response.data;
    }catch(error){
        console.log(error);
        return error;
    }
}