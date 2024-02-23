import { axiosInstance } from "../axiosInstance";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { MessagePackHubProtocol } from "@microsoft/signalr-protocol-msgpack";

export const cubeApi = {
  getCube: async (cubeName) => {
    return await axiosInstance.get(`cube/${cubeName}/face`);
  },
};

export const cubeHub = new HubConnectionBuilder()
  .withUrl(`http://localhost:5115/hubs/cube`)
  .withHubProtocol(new MessagePackHubProtocol())
  .build();
