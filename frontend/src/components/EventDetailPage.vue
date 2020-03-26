<template>
  <v-container class="fill-height" fluid>
    <v-row>
      <v-col cols="12">
        <h3 ref="radio" class="headline">Event Details - {{this.EventId}}</h3>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <h4 ref="radio" class="headline">Event Information</h4>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="2">
        <v-text-field
          v-if="ShowEventDetails"
          :readonly="ReadOnly"
          label="Identifier"
          placeholder=" "
          outlined
          Dense
          v-model="EventData.id"
        ></v-text-field>
      </v-col>
      <v-col cols="10">
        <v-text-field
          v-if="ShowEventDetails"
          :readonly="ReadOnly"
          label="Title"
          placeholder=" "
          outlined
          Dense
          v-model="EventData.title"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <v-text-field
          v-if="ShowEventDetails"
          :readonly="ReadOnly"
          label="Description"
          placeholder=" "
          outlined
          Dense
          v-model="EventData.description"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <h4 ref="radio" class="headline">Category Information</h4>
      </v-col>
    </v-row>
    <v-row>
      <v-col
        :ref="'card' + category.categoryId"
        v-for="(category, index) in EventData.categories"
        :key="index"
        cols="3"
      >
        <v-card>
          <v-img
            :src="GetPicture(category.category.title)"
            class="white--text align-end"
            gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
            height="200px"
          >
            <v-card-title v-text="category.category.title"></v-card-title>
          </v-img>

          <v-card-actions>
            <v-spacer></v-spacer>

            <v-btn link="true" target="_blank" :href="GoogleSearch(category.category.title)">
              <v-icon>mdi-magnify</v-icon>Open
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <h4 ref="radio" class="headline">Source Information</h4>
      </v-col>
    </v-row>
    <v-row>
      <v-col
        :ref="'card' + source.sourceId"
        v-for="(source, index) in EventData.sources"
        :key="index"
        cols="3"
      >
        <v-card>
          <v-container>
            <v-list-item three-line>
              <v-list-item-content>
                <div class="overline mb-4">SOURCE</div>
                <v-list-item-title class="headline mb-1">{{source.source.id}}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn link="true" target="_blank" :href="source.source.url">
                <v-icon>mdi-open-in-new</v-icon>Open
              </v-btn>
            </v-card-actions>
          </v-container>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <h4 ref="radio" class="headline">Geometries</h4>
      </v-col>
    </v-row>
    <v-row>
      <v-col
        :ref="'card' + geometry.id"
        v-for="(geometry, index) in EventData.geometries"
        :key="index"
        cols="2"
      >
        <v-card>
          <v-container>
            <v-list-item three-line>
              <v-list-item-content>
                <div class="overline mb-4">{{geometry.type}}</div>
                <v-list-item-title class="mb-2">{{ dateFormat(geometry.date) }}</v-list-item-title>
                <div class="overline">{{ geometry.coordinates }}</div>
              </v-list-item-content>
            </v-list-item>

            <v-card-actions>
              <v-btn
                link="true"
                target="_blank"
                :title="GetGoogleMaps(geometry.coordinates)"
                :href="GetGoogleMaps(geometry.coordinates)"
              >
                <v-icon>mdi-map-marker</v-icon>
              </v-btn>
            </v-card-actions>
          </v-container>
        </v-card>
      </v-col>
    </v-row>
    <footer class="footer fixed-bottom">
      <v-btn color="primary" @click="btnBackEvent">
        <v-icon>mdi-keyboard-return</v-icon>Back
      </v-btn>
    </footer>
  </v-container>
</template>
<script>
import ApiService from "@/common/api.service.js";
import loading from "@/mixins/loading.js";
import router from "@/mixins/router.js";
import datetime from "@/mixins/datetime.js";

export default {
  mixins: [loading, router, datetime],
  data() {
    return {
      EventData: null
    };
  },
  mounted() {
    if (this.EventId) this.EventLoad(this.EventId);
  },
  methods: {
    EventLoad(EventId) {
      this.loadingPromises([ApiService.get("Event/GetById", EventId)]).then(
        data => {
          this.EventData = data[0].data;
        }
      );
    },
    btnBackEvent() {
      let route = this.routeFindByName("Events");
      this.$emit("redirectPage", route);
    },
    GetPicture(type) {
      if (type.toUpperCase() == "WILDFIRES")
        return require("@/assets/wildfires.jpg");
      else if (type.toUpperCase() == "VOLCANOES")
        return require("@/assets/volcano.jpg");
      else if (type.toUpperCase() == "SEVERE STORMS")
        return require("@/assets/severeStorms.jpg");
      return require("@/assets/seaAndLake.jpg");
    },
    GoogleSearch(word) {
      return (
        "http://www.google.com/search?q=" + word + " " + this.EventData.title
      );
    },
    GetGoogleMaps(coordinates) {
      return "https://www.google.com/maps/search/" + coordinates;
    }
  },
  computed: {
    EventId() {
      return this.$route.params.id;
    },
    ShowEventDetails() {
      return this.EventData !== null;
    },
    ReadOnly() {
      return true;
    }
  }
};
</script>