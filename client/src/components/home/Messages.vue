<template>
  <div class="form fade-in-on-scroll">
    <div class="form-header">
      <h1>Say Hi</h1>
    </div>
    <div>
      <form>
        <div class="row">
          <div class="six columns">
            <input type="text" placeholder="Your name" v-model="formData.name" required maxlength="70" />
          </div>
          <div class="six columns">
            <input type="email" placeholder="Your email" v-model="formData.email" required maxlength="200" />
          </div>
        </div>
        <textarea placeholder="Hi Sara …" v-model="formData.content" required maxlength="1000"></textarea>
        <div class="row">
          <div class="six columns">
            <button class="button send-button icon-rotate" v-on:click.prevent="Send">
              <span>Send</span>
              <img class="icon" src="@/assets/home/images/send.png" alt="Send">
            </button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>


<script setup>
import messagesService from '@/services/messagesService'
import { useToast } from 'vue-toastification'
import { reactive } from 'vue'

const formData = reactive({
  name: "",
  email: "",
  content: ""
});

const Send = async () => {
  const toast = useToast()
  try {
    messagesService.create(formData).then(response => {
      ClearForm()
      if (response.status == 200)
        toast.success("Message sent. Thank you!")
    })
  }
  catch (errorMsg) {
    toast.error("Something went wrong")
  }
};

const ClearForm = async () => {
  formData.name = formData.email = formData.content = ''
}
</script>


