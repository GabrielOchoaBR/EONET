<template>
  <v-container class="fill-height" fluid>
    <v-row class="fill-height">
      <v-col>
        <v-card-title>
          Events Tracker
          <v-spacer></v-spacer>
          <v-text-field
            v-model="searchById"
            append-icon="mdi-magnify"
            label="Search by Id"
            single-line
            hide-details
            @keypress="txtsearchById_keyPress"
          ></v-text-field>
        </v-card-title>
        <v-data-table
          :headers="headers"
          :items="dataSource"
          :options.sync="options"
          :server-items-length="rowCount"
          :items-per-page="5"
          
        >
        <template v-slot:body="{ items }">
            <tbody>
              <tr :class="item.closed ? 'bgGray' : ''" v-for="(item) in items" :key="item.name">
                <td><v-icon small class="mr-2" @click="view(item)">mdi-eye</v-icon></td>
                <td>{{ item.id }}</td>
                <td>{{ item.title }}</td>
                <td>{{ getStatus(item.closed) }}</td>
              </tr>
            </tbody>
        </template>
        </v-data-table>
      </v-col>
    </v-row>
  </v-container>
</template> 

<script>
import ApiService from "@/common/api.service.js";
import loading from "@/mixins/loading.js";
import router from "@/mixins/router.js";

export default {
  mixins: [loading, router],
  data() {
    return {
      headers: [
        { text: "Actions", value: "actions", sortable: false },
        { text: "Identifier", value: "id" },
        { text: "Title", value: "title" },
        { text: "Status", value: "closed" }
      ],
      options: {},
      dataSource: [],
      searchById: null,
      userFilters: null,
      rowCount: 0,
      isFirstLoad: true
    };
  },
  mounted() {
    this.LoadDataSource();
  },
  watch: {
    options: {
      handler() {
        this.LoadDataSource();
      },
      deep: true
    }
  },
  methods: {
    LoadDataSource() {
      const { sortBy, sortDesc, page, itemsPerPage } = this.options;
      var orderBy = "";

      if (sortBy != "")
        orderBy = sortBy[0] + " " + (!sortDesc[0] ? "ASC" : "DESC");

      var pagedRequestDto = {
        userFilters: this.userFilters,
        orderBy: orderBy,
        currentPage: page - 1,
        pageSize: itemsPerPage
      };

      this.loadingPromises([
        ApiService.post("Event/GetAll", pagedRequestDto)
      ]).then(data => {
        var Return = data[0].data;
        this.rowCount = Return.rowCount;
        this.dataSource = Return.queryable;
      });
    },
    view(item) {
      let route = this.routeFindByName("EventDetails");

      route.title = "Event Details - " + item.id;
      route.params = { id: item.id };

      this.$emit("redirectPage", route);
    },
    txtsearchById_keyPress(obj) {
      if (obj.keyCode == 13) {
        if (this.searchById != "") this.btnFilter_Click();
        else this.btnFilterReset_Click();
      }
    },
    btnFilter_Click() {
      this.userFilters =
        ' id.Contains("' +
        this.searchById +
        '") || title.Contains("' +
        this.searchById +
        '") || description.Contains("' +
        this.searchById +
        '") ';
      this.options.page = 1;
      this.LoadDataSource();
    },
    btnFilterReset_Click() {
      this.userFilters = null;
      this.LoadDataSource();
    },
    getStatus(closed) {
      return closed ? "Closed" : "Open";
    },
  }
};
</script>

<style scoped>
.bgGray {
  background-color: lightgray;
  color: gray;
  font-weight: bold;
}
</style>