import { axiosInstance } from "../axiosInstance";

export const cubeApi = {
  getCube: async (cubeName) => {
    return await axiosInstance.get(`cube/${cubeName}`);
  },
};
