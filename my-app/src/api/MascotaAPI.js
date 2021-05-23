import {axiosBase as axios} from "./AxiosConfig";

export const getAll =  async () =>{
    try{
        const response = await axios.get("/mascota/getall");
        console.log("response",response);
    }catch(error){
        console.log(error);
        return error;
    }
}