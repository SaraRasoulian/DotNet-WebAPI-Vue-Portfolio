<template>
  <div class="form fade-in-on-scroll">
    <div class="form-header">
      <h1>Say Hi</h1>
    </div>
    <div>
      <form>
        <div class="row">
          <div class="six columns">
            <input type="text" placeholder="Your name">
          </div>
          <div class="six columns">
            <input type="email" placeholder="Your email">
          </div>
        </div>
        <textarea placeholder="Hi Sara …"></textarea>
        <div class="row">
          <div class="six columns">
            <button class="button send-button icon-rotate" type="submit">
              <span>Send</span>
              <img class="icon" src="@/assets/home/images/send.png" alt="Send">
            </button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {}
</script>


