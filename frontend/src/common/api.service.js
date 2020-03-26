import config from "@/common/config.js";
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";

const ApiService = {
    init() {
        Vue.use(VueAxios, axios);
        Vue.axios.defaults.baseURL = config.API_URL;
    },

    query(resource, params = {}) {
        return Vue.axios.get(resource, { params: params });
    },

    get(resource, slug = "") {
        return Vue.axios.get(`${resource}/${slug}`);
    },

    post(resource, params, options = undefined) {
        return Vue.axios.post(`${resource}`, params, options);
    },

    update(resource, slug, params) {
        return Vue.axios.put(`${resource}/${slug}`, params);
    },

    put(resource, params) {
        return Vue.axios.put(`${resource}`, params);
    },

    delete(resource) {
        return Vue.axios.delete(resource);
    }
};

export default ApiService;