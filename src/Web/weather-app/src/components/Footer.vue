<template>
  <footer>
    <div class="container">
      <div class="row">
        <div class="col-lg-4 col-md-6">
          <h3>Site Map</h3>
          <ul class="list-unstyled three-column">
            <li>Home</li>
            <li>Services</li>
            <li>About</li>
            <li>Code</li>
            <li>Design</li>
            <li>Host</li>
            <li>Contact</li>
            <li>Company</li>
          </ul>
        </div>

        <div class="col-lg-4 col-md-6">
          <h3>latest Articles</h3>
          <div class="media">
            <a href="#" class="pull-left">
              <img src="https://appsfactory.de/wp-content/uploads/2018/07/Machine_Learning.png" style="width:64px; height:64px;" alt class="media-object" />
            </a>
            <div class="media-body">
              <h4 class="media-heading">MACHINE LEARNING</h4>
              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
            </div>
          </div>

          <div class="media">
            <a href="#" class="pull-left">
              <img src="https://appsfactory.de/wp-content/uploads/2018/07/Design_Thinking.png" style="width:64px; height:64px;" alt class="media-object" />
            </a>
            <div class="media-body">
              <h4 class="media-heading">DESIGN THINKING</h4>
              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
            </div>
          </div>

          <div class="media">
            <a href="#" class="pull-left">
              <img src="https://appsfactory.de/wp-content/uploads/2018/07/UATS.png" style="width:64px; height:64px;" alt class="media-object" />
            </a>
            <div class="media-body">
              <h4 class="media-heading">USER ACCEPTANCE</h4>
              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
            </div>
          </div>
        </div>

        <div class="col-lg-4">
          <h3>Our Work</h3>
          <img class="img-thumbnail" src="https://appsfactory.de/wp-content/uploads/2018/07/Individualsoftware.png" style="width:150px;" alt />
          <img class="img-thumbnail" src="https://appsfactory.de/wp-content/uploads/2018/07/Cloud_Services.png" style="width:150px;" alt />
          <img class="img-thumbnail" src="https://appsfactory.de/wp-content/uploads/2018/07/Chatbots.png" style="width: 150px;" alt />
          <img class="img-thumbnail" src="https://appsfactory.de/wp-content/uploads/2018/07/Technologie_Beratung.png" style="width: 150px;" alt />
        </div>
      </div>
    </div>
    <div class="copyright text-center">
      Copyright &copy; 2019
      <span>Appsfactory - Lepzig</span>
    </div>
  </footer>
</template>
  
    <script>
export default {
  name: "Footer",
  props: {
    msg: String
  }
};
</script>

<style scoped>
</style>