<template>
  <div class="message-page">
    <v-card>
      <v-card-title class="headline" primary-title>Отправить уведомление</v-card-title>
      <v-card-text>
        <v-form v-model="valid" lazy-validation>
          <v-text-field :rules="formRules" v-model="token" flat color="blue" label="Token" required></v-text-field>
          <v-text-field :rules="formRules" v-model="user" flat color="blue" label="User" required></v-text-field>
          <v-textarea :rules="formRules" v-model="text" color="blue" outline label="Text" required></v-textarea>
          <v-btn @click="send()" flat :disabled="!valid" color="blue">Отправить</v-btn>
        </v-form>
      </v-card-text>
      <v-card-actions></v-card-actions>
      <v-alert
        :value="true"
        :style="alertText==''?'display:none':'display: flex'"
        :type="alert"
      >{{alertText}}</v-alert>
    </v-card>
  </div>
</template>

<script>
export default {
  name: "Message",
  data() {
    return {
      alert: "success",
      alertText: "",
      valid: false,
      formRules: [v => !!v || "Field is required"],
      token: "",
      user: "",
      text: ""
    };
  },
  mounted: function() {
    this.valid = false;
  },
  methods: {
    send: function() {
      if (!this.valid) {
        return;
      }
      $.ajax({
        type: "POST",
        url: "http://localhost:62374/api/sendMessage/",
        data: JSON.stringify({
          token: this.token,
          user: this.user,
          text: this.text
        }),
        contentType: "application/json; charset=utf-8"
      })
        .done(function(response) {
          alert(response.responseText);
        })
        .fail(function(response) {
          alert(response.responseText);
        });
    }
  }
};
</script>

<style scoped>
.message-page {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
}
.v-textarea {
  margin-top: 25px;
}
</style>
